using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrepolisBot.Utils
{
	public static class HtmlElementExtenstion
	{
		public static void ParseTownCapacity(HtmlElement container, out int currectCapacity, out int maxCapacity)
		{
			currectCapacity = 0;
			maxCapacity = 0;

			if(container != null)
			{
				HtmlElementCollection containerChildCollection = container.All;

				foreach(HtmlElement containerChild in containerChildCollection)
				{
					if(containerChild.GetAttribute("className") == "amounts")
					{
						HtmlElementCollection amoutsElementCollection = containerChild.All;

						if(amoutsElementCollection.Count >= 1 && amoutsElementCollection[0] != null)
						{
							currectCapacity += int.Parse(amoutsElementCollection[0].InnerText);
						}

						if(amoutsElementCollection.Count >= 2 && amoutsElementCollection[1] != null)
						{
							string amount = amoutsElementCollection[1].InnerText;
							if(!string.IsNullOrEmpty(amount))
							{
								amount = amount.Replace('+', ' ');
								amount = amount.Trim();

								currectCapacity += int.Parse(amount);
							}
						}

						if(amoutsElementCollection.Count >= 4 && amoutsElementCollection[3] != null)
						{
							maxCapacity = int.Parse(amoutsElementCollection[3].InnerText);
						}
					}
				}
			}
		}


		/// <summary>
		/// Gets the current amount of resources that is displayed on the UI.
		/// </summary>
		/// <param name="document">The page document</param>
		/// <param name="woodAmount">The current wood resource amount that is displayed on the UI.</param>
		/// <param name="rockAmount">The current rock resource amount that is displayed on the UI.</param>
		/// <param name="silverAmount">The current silver resource amount that is displayed on the UI.</param>
		public static void GetTownCurrentAmountOfResources(HtmlDocument document, out int woodAmount, out int rockAmount, out int silverAmount)
		{
			woodAmount = 0;
			rockAmount = 0;
			silverAmount = 0;

			if(document != null)
			{
				HtmlElement container = document.GetElementById("ui_box");

				if(container != null)
				{
					HtmlElementCollection containerElementCollection = container.All;
					HtmlElement resourceContainer = null;

					foreach(HtmlElement containerElement in containerElementCollection)
					{
						if(containerElement.GetAttribute("className").Contains("ui_resources_bar"))
						{
							resourceContainer = containerElement;
						}
					}

					if(resourceContainer != null)
					{
						HtmlElementCollection resourceElementCollection = resourceContainer.Children;

						if(resourceElementCollection.Count >= 1 && resourceElementCollection[0] != null)
						{
							GetTownCurrentResourceAmount(resourceElementCollection[0], out woodAmount);
						}

						if(resourceElementCollection.Count >= 2 && resourceElementCollection[1] != null)
						{
							GetTownCurrentResourceAmount(resourceElementCollection[1], out rockAmount);
						}

						if(resourceElementCollection.Count >= 3 && resourceElementCollection[2] != null)
						{
							GetTownCurrentResourceAmount(resourceElementCollection[2], out silverAmount);
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets the current amount of resource that is displayed on the UI.
		/// </summary>
		/// <param name="parentResourceContainer">The parent container in which the resources is displayed.</param>
		/// <param name="amount">The current resource amount that is displayed on the UI.</param>
		private static void GetTownCurrentResourceAmount(HtmlElement parentResourceContainer, out int amount)
		{
			amount = 0;

			if(parentResourceContainer != null)
			{
				HtmlElementCollection parentResourceContainerElementCollection = parentResourceContainer.Children;

				if(parentResourceContainerElementCollection.Count >= 3 && parentResourceContainerElementCollection[2] != null)
				{
					string amountString = parentResourceContainerElementCollection[2].InnerText;
					if(!string.IsNullOrEmpty(amountString))
					{
						amount = int.Parse(amountString);
					}
				}
			}
		}

		/// <summary>
		/// Inserts an amount of resources inside the trade overview controls.
		/// </summary>
		/// <param name="document">The page document.</param>
		/// <param name="woodAmount">The amount of wood to insert.</param>
		/// <param name="rockAmount">The amount of rock to insert.</param>
		/// <param name="silverAmount">The amount of silver to insert.</param>
		public static void InsertResourcesInTradeOverview(HtmlDocument document, int woodAmount, int rockAmount, int silverAmount)
		{
			if(document != null)
			{
				HtmlElement woodContainer = document.GetElementById("trade_type_wood");
				InsertResourceInControl(woodContainer, woodAmount);

				HtmlElement rockContainer = document.GetElementById("trade_type_stone");
				InsertResourceInControl(rockContainer, rockAmount);

				HtmlElement silverContainer = document.GetElementById("trade_type_iron");
				InsertResourceInControl(silverContainer, silverAmount);
			}
		}

		/// <summary>
		/// Inserts a specific amount of resources into its control in the trade overview
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="amount">The amount to insert.</param>
		private static void InsertResourceInControl(HtmlElement container, int amount)
		{
			if(container != null)
			{
				HtmlElementCollection containerElementCollection = container.Children;

				if(containerElementCollection.Count >= 3 && containerElementCollection[2] != null)
				{
					HtmlElementCollection firstChild = containerElementCollection[2].Children;
					if(firstChild.Count == 1)
					{
						HtmlElementCollection secondChild = firstChild[0].Children;

						if(secondChild.Count == 1)
						{
							HtmlElement resourceElement = secondChild[0];

							resourceElement.Focus();
							//resourceElement.InnerText = amount.ToString();
							resourceElement.SetAttribute("value", amount.ToString());

						}
					}
				}
			}
		}
	}
}