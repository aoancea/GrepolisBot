using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using GrepolisBot.Utils;
using GrepolisBot.Models;

namespace GrepolisBot
{
    public partial class Form1 : Form
    {
        private HtmlElementCollection linkCollection;
        private HtmlDocument externalDocument;

        private Thread startAsync;
        private Thread startCollecting;
        private Thread demandAsync;
        private bool isLooting = false;

        private bool hasLootedBefore = false;

        DateTime start;
        DateTime endTime;

        private bool hideFarmDialog = false;
        private HtmlElement farmOverviewElement = null;
        private string styleDisplayBlock = string.Empty;
        private string styleDisplayNone = string.Empty;

        bool warehouseOptimization = true;
        bool randomizeTimer = true;

        public List<ResourcesAudit> ResourceAuditList = new List<ResourcesAudit>();
        System.Windows.Forms.Timer timerCity1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity2 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity3 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity4 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity5 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity6 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity7 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity8 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity9 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCity10 = new System.Windows.Forms.Timer();


        public Form1()
        {
            InitializeComponent();
            rdoDemand.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // reset
            AbortThreadExecution();
            externalDocument = null;

            // initialization
            externalDocument = webBrowser1.Document;

            CreateAsyncCollection();
            StartTimer();
        }

        private void CreateAsyncCollection()
        {
            startCollecting = new Thread(() =>
            {
                CollectResources();
            });

            startCollecting.Start();
        }

        private void CollectResources()
        {
            // captcha image id = recaptcha_image
            // captcha response field id = recaptcha_response_field
            // confirm button = <div class="btn_confirm button_new square accept"></div>


            HtmlElement captchaElement = externalDocument.GetElementById("recaptcha_image");
            if (captchaElement == null)
            {
                // there is no captcha => we can farm

                linkCollection = externalDocument.GetElementsByTagName("a");
                HtmlElement farmTownOverview = null;

                foreach (HtmlElement link in linkCollection)
                {
                    if (link.GetAttribute("name") == "farm_town_overview")
                    {
                        farmTownOverview = link;
                        break;
                    }
                }

                try
                {
                    farmTownOverview.InvokeMember("Click"); // open up farm overview - provided buy the captain
                    hasLootedBefore = false;
                    Thread.Sleep(2000); // w8 for 1 second for tab to appear

                    var townListContainer = externalDocument.GetElementById("fto_town_list");
                    if (townListContainer == null)
                    {
                        // we try to open the overview again. FOR SLOWER CONNECTIONS
                        farmTownOverview.InvokeMember("Click"); // open up farm overview - provided buy the captain
                        hasLootedBefore = false;
                        Thread.Sleep(2000); // w8 for 1 second for tab to appear
                    }

                    if (townListContainer != null)
                    {
                        HtmlElement jumpToCurrentCityButton = externalDocument.GetElementById("map_jump_to_current_town_button");
                        if (jumpToCurrentCityButton != null)
                        {
                            // reshow button after farming has stopped.
                            jumpToCurrentCityButton.Style = "display: none";
                        }

                        // load farm overview element
                        this.LoadFarmOverviewElement();

                        var townListContainerItemList = townListContainer.GetElementsByTagName("li");
                        List<HtmlElement> cityList = new List<HtmlElement>();

                        foreach (HtmlElement city in townListContainerItemList)
                        {
                            if (city.GetAttribute("className").Contains("fto_town"))
                            {
                                cityList.Add(city);
                            }
                        }

                        if (cityList.Count > 0)
                        {
                            HtmlElement demandTab = externalDocument.GetElementById("fto_claim"); // get demand tab selection button
                            HtmlElement lootTab = externalDocument.GetElementById("fto_pillage"); // get loot tab selection button

                            foreach (HtmlElement element in cityList)
                            {
                                HtmlElementCollection resourceDetail = element.GetElementsByTagName("div");
                                HtmlElementCollection resourceDetailList = resourceDetail[0].GetElementsByTagName("span");

                                int wood = 0;
                                int stone = 0;
                                int iron = 0;
                                int warehouseCapacity = 0;

                                foreach (HtmlElement resourceElement in resourceDetailList)
                                {
                                    if (resourceElement.GetAttribute("className").Contains("resource_wood_icon wood fto_resource_count"))
                                    {
                                        HtmlElementCollection woodValue = resourceElement.GetElementsByTagName("span");
                                        wood = int.Parse(woodValue[woodValue.Count - 1].InnerText);
                                    }

                                    if (resourceElement.GetAttribute("className").Contains("resource_stone_icon stone fto_resource_count"))
                                    {
                                        HtmlElementCollection stoneValue = resourceElement.GetElementsByTagName("span");
                                        stone = int.Parse(stoneValue[stoneValue.Count - 1].InnerText);
                                    }

                                    if (resourceElement.GetAttribute("className").Contains("resource_iron_icon iron fto_resource_count"))
                                    {
                                        HtmlElementCollection ironValue = resourceElement.GetElementsByTagName("span");
                                        iron = int.Parse(ironValue[ironValue.Count - 1].InnerText);
                                    }

                                    if (resourceElement.GetAttribute("className").Contains("small storage_icon fto_resource_count"))
                                    {
                                        warehouseCapacity = int.Parse(resourceElement.InnerText);
                                    }
                                }

                                bool acceptsWood = warehouseCapacity - wood > 500;
                                bool acceptsStone = warehouseCapacity - stone > 500;
                                bool acceptsIron = warehouseCapacity - iron > 500;

                                bool acceptsResources = true;

                                if (this.warehouseOptimization)
                                {
                                    acceptsResources = acceptsWood && acceptsStone && acceptsIron;
                                }
                                else
                                {
                                    acceptsResources = acceptsWood || acceptsStone || acceptsIron;
                                }

                                if (acceptsResources)
                                {
                                    element.InvokeMember("Click");
                                    Thread.Sleep(2000); // w8 for selection to take place

                                    HtmlElement resourceQuantity = externalDocument.GetElementById("max_claim_resources");
                                    if (resourceQuantity.InnerText != "+0")
                                    {
                                        if (this.isLooting)
                                        {
                                            lootTab.InvokeMember("Click");
                                            hasLootedBefore = true;
                                            Thread.Sleep(500); // w8 for tab selection

                                            HtmlElement moodDecreaseElement = externalDocument.GetElementById("max_satisfaction_reduce");
                                            bool canBeLooted = (moodDecreaseElement.InnerText == "0");
                                            if (!canBeLooted)
                                            {
                                                demandTab.InvokeMember("Click");
                                                hasLootedBefore = false;
                                            }
                                        }
                                        else
                                        {
                                            if (hasLootedBefore)
                                            {
                                                demandTab.InvokeMember("Click");
                                            }
                                        }

                                        Thread.Sleep(2000); // w8 for selection to take place

                                        HtmlElement claimButton = externalDocument.GetElementById("fto_claim_button"); // get the request resources button
                                        claimButton.InvokeMember("Click");

                                        Thread.Sleep(2000); // w8 for resources to be gathered
                                    }
                                }
                            }
                        }

                        #region Close farm overview
                        HtmlElementCollection internalLinkCollection = this.farmOverviewElement.GetElementsByTagName("a");
                        foreach (HtmlElement link in internalLinkCollection)
                        {
                            if (link.GetAttribute("role") == "button")
                            {
                                link.InvokeMember("Click");
                                this.farmOverviewElement = null; // we closed the farm overview.
                                break;
                            }
                        }
                        #endregion

                        if (jumpToCurrentCityButton != null)
                        {
                            // reshow button after farming has stopped.
                            jumpToCurrentCityButton.Style = "display: block";
                        }
                    }

                    #region Old code

                    //demandAsync = new Thread(new ThreadStart(() =>
                    //{
                    //	try
                    //	{
                    //		System.Threading.Thread.Sleep(5000);
                    //		foreach (HtmlElement link in internalLinkCollection)
                    //		{
                    //			if (link.GetAttribute("id") == "fto_claim_button")
                    //			{
                    //				link.InvokeMember("Click");
                    //				break;
                    //			}
                    //		}

                    //		System.Threading.Thread.Sleep(1000);
                    //		foreach (HtmlElement link in internalLinkCollection)
                    //		{
                    //			if (link.GetAttribute("role") == "button")
                    //			{
                    //				link.InvokeMember("Click");
                    //				break;
                    //			}
                    //		}
                    //	}
                    //	catch (Exception ex)
                    //	{
                    //		MessageBox.Show(ex.InnerException.ToString());
                    //	}
                    //}));

                    //demandAsync.Start();

                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void rdoLoot_CheckedChanged(object sender, EventArgs e)
        {
            this.isLooting = this.rdoLoot.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HtmlElement mapContainer = this.webBrowser1.Document.GetElementById("map_towns");
            if (mapContainer != null)
            {
                List<HtmlElement> ownTownList = new List<HtmlElement>();

                HtmlElementCollection townContainerCollection = mapContainer.GetElementsByTagName("div");
                foreach (HtmlElement element in townContainerCollection)
                {
                    if (element.GetAttribute("className").Contains("farmtown_owned farmtown_owned_on_same_island"))
                    {
                        ownTownList.Add(element);
                    }
                }

                if (ownTownList.Count > 0)
                {
                    foreach (HtmlElement element in ownTownList)
                    {
                        HtmlElementCollection townLink = element.GetElementsByTagName("a");

                        foreach (HtmlElement link in townLink)
                        {
                            //MethodInfo method = link.GetType().GetMethod("click");
                            //method.Invoke(

                            //string currentUri = this.webBrowser1.Url.ToString() + "#eyJpZCI6IjE4NjI1IiwiaXgiOjI2MywiaXkiOjUwMywidHAiOiJmYXJtX3Rvd24ifQ==";
                            //this.webBrowser1.Navigate(currentUri);
                            //this.webBrowser1.Document.InvokeScript("$(window).hashchange();");

                            link.InvokeMember("touchstart");

                            link.AttachEventHandler("click", (ev, ec) =>
                            {
                                var eventArgs = ec;
                            });

                            Thread.Sleep(new TimeSpan(0, 0, 1));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Abords all thread execution and sets the value to null for all thread pointers.
        /// </summary>
        private void AbortThreadExecution()
        {
            if (startAsync != null)
            {
                startAsync.Abort();
                startAsync = null;
            }

            if (startCollecting != null)
            {
                startCollecting.Abort();
                startCollecting = null;
            }

            if (demandAsync != null)
            {
                demandAsync.Abort();
                demandAsync = null;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (cbxHideInTray.Checked)
                {
                    this.Visible = false;
                }
            }

            int width = this.Size.Width - 30;
            int height = this.Size.Height - this.groupBox1.Size.Height - 60;
            tabControl1.Size = new System.Drawing.Size(width, height + 58);
            webBrowser1.Size = new System.Drawing.Size(width - 10, height - 30);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void StartTimer()
        {
            timer1.Stop();

            start = DateTime.UtcNow;

            int secondsToAdd = 10;

            if (this.randomizeTimer)
            {
                Random rnd = new Random();

                secondsToAdd += rnd.Next(10);
            }

            endTime = start.AddMinutes(10).AddSeconds(secondsToAdd);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = endTime - DateTime.UtcNow;
            if (remainingTime < TimeSpan.Zero)
            {
                timer1.Enabled = false;

                StartTimer();

                CreateAsyncCollection();
            }
            else
            {
                lblFarmCountDown.Text = remainingTime.ToString();
            }
        }

        private void chkHideFarmingDialog_CheckedChanged(object sender, EventArgs e)
        {
            this.hideFarmDialog = this.chkHideFarmingDialog.Checked;

            this.HideShowFarmOverview();
        }


        /// <summary>
        /// Loads the farm overview element.
        /// Also applies other logic to it.
        /// Applied logic:
        /// - "display: none;" if selected by the user
        /// </summary>
        /// <returns>A HtmlElement representing the farm overview iu-dialog form</returns>
        private void LoadFarmOverviewElement()
        {
            HtmlElementCollection divCollection = externalDocument.GetElementsByTagName("div");
            if (divCollection != null)
            {
                bool found = false;
                foreach (HtmlElement element in divCollection)
                {
                    if (element.GetAttribute("className") == "ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable js-window-main-container")
                    {
                        //HtmlElementCollection searchElementList = element.GetElementsByTagName("ul"); // list of all divs inside the current HtmlElement
                        //if (searchElementList != null)
                        //{
                        //    foreach (HtmlElement searchElement in searchElementList)
                        //    {
                        //        if (searchElement.GetAttribute("id") == "fto_town_list")
                        //        {
                        //            this.farmOverviewElement = element;
                        //            this.styleDisplayBlock = this.farmOverviewElement.Style; // we take its initial style
                        //            found = true;
                        //            break;
                        //        }
                        //    }
                        //}

                        this.farmOverviewElement = element;
                        this.styleDisplayBlock = this.farmOverviewElement.Style;
                        found = true;
                        break;
                    }

                    if (found)
                    {
                        break; // we found the element -> we break the search
                    }
                }
            }

            this.HideShowFarmOverview();
        }

        /// <summary>
        /// Hides or shows the farm overview depeding on the existance of it and on the user option.
        /// </summary>
        private void HideShowFarmOverview()
        {
            if (this.farmOverviewElement != null)
            {
                if (this.hideFarmDialog)
                {
                    // getting the current style before hiding.
                    this.styleDisplayBlock = this.farmOverviewElement.Style;
                    this.styleDisplayNone = this.styleDisplayBlock.Replace("block", "none");

                    farmOverviewElement.Style = this.styleDisplayNone;
                }
                else
                {
                    farmOverviewElement.Style = this.styleDisplayBlock;
                }
            }
        }

        private void cbxWarehouseOptimization_CheckedChanged(object sender, EventArgs e)
        {
            this.warehouseOptimization = this.cbxWarehouseOptimization.Checked;
        }

        private void cbxRandomizeTimer_CheckedChanged(object sender, EventArgs e)
        {
            this.randomizeTimer = this.cbxRandomizeTimer.Checked;
        }

        private void btnLoadResources_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;

            if (document != null)
            {
                // ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable ui-resizable

                HtmlElementCollection bodyList = document.GetElementsByTagName("body");

                if (bodyList != null && bodyList.Count == 1)
                {
                    HtmlElement body = bodyList[0];
                    HtmlElementCollection bodyChildrenCollection = body.Children;

                    HtmlElement tradeForm = null;

                    foreach (HtmlElement child in bodyChildrenCollection)
                    {
                        if (child.GetAttribute("className").Contains("ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable ui-resizable"))
                        {
                            HtmlElementCollection childElementCollection = child.GetElementsByTagName("div");

                            foreach (HtmlElement element in childElementCollection)
                            {
                                if (element.GetAttribute("id") == "trade_tab")
                                {
                                    tradeForm = child;
                                    break;
                                }
                            }

                            if (tradeForm != null)
                            {
                                break;
                            }
                        }
                    }

                    if (tradeForm != null)
                    {
                        // we found the trade form
                        // ui-dialog-title

                        string fromCityName = string.Empty;
                        string toCityName = string.Empty;

                        int senderMaxAllowedResources = 0;
                        int receiverMaxAllowedResourcesPerStack = 0;

                        int senderCurrentWood = 0;
                        int senderCurrentRock = 0;
                        int senderCurrentSilver = 0;

                        int receiverCurrentWood = 0;
                        int receiverCurrentRock = 0;
                        int receiverCurrentSilver = 0;

                        HtmlElementCollection documentElementCollection = document.All;
                        foreach (HtmlElement element in documentElementCollection)
                        {
                            if (element.GetAttribute("className") == "town_name js-townname-caption js-rename-caption ui-game-selectable")
                            {
                                fromCityName = element.InnerText; // checked
                            }
                        }

                        HtmlElementExtenstion.GetTownCurrentAmountOfResources(document, out senderCurrentWood, out senderCurrentRock, out senderCurrentSilver);

                        //MessageBox.Show(string.Format("Sender current resources: Wood : {0}, Rock : {1}, Silver : {2}", senderCurrentWood, senderCurrentRock, senderCurrentSilver));

                        HtmlElementCollection tradeFormElementCollection = tradeForm.All;
                        foreach (HtmlElement element in tradeFormElementCollection)
                        {
                            if (element.GetAttribute("className") == "ui-dialog-title")
                            {
                                toCityName = element.InnerText; // checked
                            }

                            if (element.GetAttribute("className") == "caption")
                            {
                                HtmlElementCollection captionElementCollection = element.All;
                                HtmlElement maxCapacity = captionElementCollection[2];

                                if (maxCapacity != null)
                                {
                                    senderMaxAllowedResources = int.Parse(maxCapacity.InnerText);
                                }
                            }

                            #region Receiver current wood
                            if (element.GetAttribute("id") == "town_capacity_wood")
                            {
                                HtmlElementExtenstion.ParseTownCapacity(element, out receiverCurrentWood, out receiverMaxAllowedResourcesPerStack);
                            }
                            #endregion

                            #region Receiver current rock
                            if (element.GetAttribute("id") == "town_capacity_stone")
                            {
                                HtmlElementExtenstion.ParseTownCapacity(element, out receiverCurrentRock, out receiverMaxAllowedResourcesPerStack);
                            }
                            #endregion

                            #region Receiver current silver
                            if (element.GetAttribute("id") == "town_capacity_iron")
                            {
                                HtmlElementExtenstion.ParseTownCapacity(element, out receiverCurrentSilver, out receiverMaxAllowedResourcesPerStack);
                            }
                            #endregion

                        }

                        //MessageBox.Show(string.Format("Receiver current resources: Wood : {0}, Rock : {1}, Silver : {2}", receiverCurrentWood, receiverCurrentRock, receiverCurrentSilver));

                        int senderResourcesAmount = senderCurrentWood + senderCurrentRock + senderCurrentSilver;
                        int maxAmountOfResourcesToSend = senderResourcesAmount > senderMaxAllowedResources ? senderMaxAllowedResources : senderResourcesAmount;
                        int maxAmountOfResourcesToReceive =
                            3 * receiverMaxAllowedResourcesPerStack -
                            (receiverCurrentWood + receiverCurrentRock + receiverCurrentSilver) -
                            600; // we leave a gap of 200 resources for each stack

                        int actualReceiverResourcesAmount = maxAmountOfResourcesToReceive > maxAmountOfResourcesToSend ? maxAmountOfResourcesToSend : maxAmountOfResourcesToReceive;

                        List<Resource> resourceList = new List<Resource>();
                        resourceList.Add(new Resource() { Amount = receiverCurrentWood, Type = Enums.ResourceType.Wood });
                        resourceList.Add(new Resource() { Amount = receiverCurrentRock, Type = Enums.ResourceType.Rock });
                        resourceList.Add(new Resource() { Amount = receiverCurrentSilver, Type = Enums.ResourceType.Silver });

                        resourceList = resourceList.OrderBy(w => w.Amount).ToList();

                        bool hasFinised = false;

                        do
                        {
                            int firstLowerAmount = resourceList[0].Amount;
                            List<Resource> firstLowerAmountResourceList = resourceList.Where(w => w.Amount == firstLowerAmount).ToList();
                            hasFinised = actualReceiverResourcesAmount == 0;

                            if (!hasFinised)
                            {
                                int deltaPerStack = 0;
                                if (resourceList.Count != firstLowerAmountResourceList.Count)
                                {
                                    int secondLowerAmount = resourceList[firstLowerAmountResourceList.Count].Amount;
                                    deltaPerStack = secondLowerAmount - firstLowerAmount;

                                    int deltaTotal = deltaPerStack * firstLowerAmountResourceList.Count;

                                    if (deltaTotal > actualReceiverResourcesAmount)
                                    {
                                        deltaPerStack = actualReceiverResourcesAmount / firstLowerAmountResourceList.Count;
                                        actualReceiverResourcesAmount = 0;
                                    }
                                    else
                                    {
                                        actualReceiverResourcesAmount -= deltaTotal;
                                    }
                                }
                                else
                                {
                                    deltaPerStack = actualReceiverResourcesAmount / firstLowerAmountResourceList.Count;
                                    actualReceiverResourcesAmount = 0;
                                }

                                foreach (Resource resource in firstLowerAmountResourceList)
                                {
                                    resource.Amount += deltaPerStack;
                                }
                            }

                        } while (actualReceiverResourcesAmount > 0 && !hasFinised);

                        int actualWoodAmounToSend = resourceList.Where(w => w.Type == Enums.ResourceType.Wood).Select(w => w.Amount).FirstOrDefault() - receiverCurrentWood;
                        int actualRockAmountToSend = resourceList.Where(w => w.Type == Enums.ResourceType.Rock).Select(w => w.Amount).FirstOrDefault() - receiverCurrentRock;
                        int actualSilverAmountToSend = resourceList.Where(w => w.Type == Enums.ResourceType.Silver).Select(w => w.Amount).FirstOrDefault() - receiverCurrentSilver;


                        //MessageBox.Show(string.Format("Amount to send:  Wood : {0}, Rock : {1}, Silver : {2}", actualWoodAmounToSend, actualRockAmountToSend, actualSilverAmountToSend));

                        HtmlElementExtenstion.InsertResourcesInTradeOverview(document, actualWoodAmounToSend, actualRockAmountToSend, actualSilverAmountToSend);

                        tradeForm.Focus();


                        Thread thread = new Thread(new ThreadStart(() =>
                        {
                            System.Threading.Thread.Sleep(500);

                            HtmlElement sendResourcesElement = document.GetElementById("trade_button");
                            if (sendResourcesElement != null)
                            {
                                sendResourcesElement.InvokeMember("Click");

                                HtmlElement durationElement = document.GetElementById("way_duration");
                                if (durationElement != null)
                                {
                                    string duration = durationElement.InnerText;

                                    duration = duration.Replace('~', ' ');
                                    duration = duration.Trim();

                                    string[] splitedDuration = duration.Split(':');

                                    int hours = int.Parse(splitedDuration[0]);
                                    int minutes = int.Parse(splitedDuration[1]);
                                    int seconds = int.Parse(splitedDuration[2]);

                                    this.ResourceAuditList.Add(new ResourcesAudit()
                                    {
                                        FromCity = fromCityName,
                                        ToCity = toCityName,

                                        DeliveryHours = hours,
                                        DeliveryMinutes = minutes,
                                        DeliverySeconds = seconds
                                    });

                                    this.Invoke(new MethodInvoker(ShowResourceAudit));
                                }
                            }

                        }));

                        thread.Start();
                    }
                }
            }
        }


        private void ShowResourceAudit()
        {
            if (this.ResourceAuditList != null && this.ResourceAuditList.Count > 0)
            {
                string[] filteredToCityList = this.ResourceAuditList.Select(w => w.ToCity).Distinct().ToArray();
                if (filteredToCityList != null && filteredToCityList.Length > 0)
                {
                    for (int i = 0; i < filteredToCityList.Length; i++)
                    {
                        List<ResourcesAudit> filteredList = this.ResourceAuditList.Where(w => w.ToCity == filteredToCityList[i]).OrderByDescending(w => w.TotalSeconds).ToList();

                        if (filteredList != null && filteredList.Count > 0)
                        {
                            if (i == 0)
                            {
                                this.SetupResourceAudit(gbxCity1, lblCityName1, lblCityTimer1, filteredList[0], ref timerCity1);
                            }

                            if (i == 1)
                            {
                                this.SetupResourceAudit(gbxCity2, lblCityName2, lblCityTimer2, filteredList[0], ref timerCity2);
                            }
                        }
                    }
                }
            }
        }



        private void SetupResourceAudit(GroupBox gbx, Label lblCityName, Label lblCityTimer, ResourcesAudit resourceAudit, ref System.Windows.Forms.Timer timer)
        {
            gbx.Visible = true;
            lblCityName.Text = resourceAudit.ToCity;

            DateTime endTime = DateTime.UtcNow.Add(new TimeSpan(resourceAudit.DeliveryHours, resourceAudit.DeliveryMinutes, resourceAudit.DeliverySeconds));

            timer.Enabled = false;
            timer.Stop();
            timer.Dispose();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Enabled = true;

            var timerContext = timer;

            timer.Tick += ((object sender, EventArgs e) =>
            {
                TimeSpan remainingTime = endTime - DateTime.UtcNow;
                if (remainingTime < TimeSpan.Zero)
                {
                    timerContext.Enabled = false;
                }
                else
                {
                    lblCityTimer.Text = remainingTime.ToString();
                }
            });

            timer.Start();
        }

        private void btnResetCity1_Click(object sender, EventArgs e)
        {
            gbxCity1.Visible = false;
            lblCityName1.Text = string.Empty;
            lblCityTimer1.Text = string.Empty;
            timerCity1.Stop();
            timerCity1.Dispose();
        }

        private void btnResetCity2_Click(object sender, EventArgs e)
        {
            gbxCity2.Visible = false;
            lblCityName2.Text = string.Empty;
            lblCityTimer2.Text = string.Empty;
            timerCity2.Stop();
            timerCity2.Dispose();
        }

        private void btnResetCity3_Click(object sender, EventArgs e)
        {
            gbxCity3.Visible = false;
            lblCityName3.Text = string.Empty;
            lblCityTimer3.Text = string.Empty;
            timerCity3.Stop();
            timerCity3.Dispose();
        }

        private void btnResetCity4_Click(object sender, EventArgs e)
        {
            gbxCity4.Visible = false;
            lblCityName4.Text = string.Empty;
            lblCityTimer4.Text = string.Empty;
            timerCity4.Stop();
            timerCity4.Dispose();
        }
    }

    /*
	 
	 
	 * 
	 * private void StartTimer()
		{
			timer1.Stop();

			start = DateTime.UtcNow;

			int secondsToAdd = 10;

			if(this.randomizeTimer)
			{
				Random rnd = new Random();

				secondsToAdd += rnd.Next(10);
			}

			endTime = start.AddMinutes(5).AddSeconds(secondsToAdd);
			timer1.Enabled = true;
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			TimeSpan remainingTime = endTime - DateTime.UtcNow;
			if(remainingTime < TimeSpan.Zero)
			{
				timer1.Enabled = false;

				StartTimer();

				CreateAsyncCollection();
			}
			else
			{
				lblFarmCountDown.Text = remainingTime.ToString();
			}
		}
	 
	 
	 
	 
	 
	 
	 
	 
	 
	 
	 
	 */


    public class ResourcesAudit
    {
        public string FromCity
        {
            get;
            set;
        }

        public string ToCity
        {
            get;
            set;
        }

        public int DeliveryHours
        {
            get;
            set;
        }

        public int DeliveryMinutes
        {
            get;
            set;
        }

        public int DeliverySeconds
        {
            get;
            set;
        }

        public int TotalSeconds
        {
            get
            {
                return
                    this.DeliveryHours * 3600 +
                    this.DeliveryMinutes * 60 +
                    this.DeliverySeconds;
            }
        }


        public ResourcesAudit()
        {
            this.FromCity = string.Empty;
            this.ToCity = string.Empty;

            this.DeliveryHours = 0;
            this.DeliveryMinutes = 0;
            this.DeliverySeconds = 0;
        }
    }
}