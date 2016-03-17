﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTable.cs" company="Microsoft Corporation">
//   Microsoft Corporation. All rights reserved.
//   Information Contained Herein is Proprietary and Confidential.
// </copyright>
// <summary>
//  Defines the generic properties for an Html tag structure like this: 
//
// --------------------------------------------------------------------------------------------------------------------

namespace Phoenix.Test.UI.Framework.Controls
{
    using System.Collections.Generic;
    using Phoenix.Test.UI.Framework.WebPages;
    using OpenQA.Selenium;

    /// <summary>
    /// Defines the generic properties for an Html tag structure like this: .section > .section-title ~ .section-body > .section-item.
    /// </summary>
    public class HtmlTable : HtmlControl
    {
        private Page page;

        /// <summary>
        /// Construct HtmlSection found using By accessor.
        /// </summary>
        /// <param name="page">Page where control is found.</param>
        /// <param name="by">By accessor to find element.</param>
        public HtmlTable(Page page, By by)
            : base(page, by)
        {
            this.page = page;
        }

        /// <summary>
        /// Construct HtmlSection by directly passing its element.
        /// </summary>
        /// <param name="page">Page where control is found.</param>
        /// <param name="element">IWebElement representing the control.</param>
        public HtmlTable(Page page, IWebElement element)
            : base(page, element)
        {
            this.page = page;
        }

        /////// <summary>
        /////// Gets the section title text.
        /////// </summary>
        ////public string Title
        ////{
        ////    get
        ////    {
        ////        return this.Element.FindElement(By.ClassName("section-title")).Text;
        ////    }
        ////}

        /////// <summary>
        /////// Gets the section edit link, not all situations will contains a edit link, so may be you should verify is it exist before you using it.
        /////// </summary>
        ////public HtmlLink EditLink
        ////{
        ////    get
        ////    {
        ////        return new HtmlLink(this.page, this.Element.FindElement(By.Id("editAccountLink")));
        ////    }
        ////}

        /// <summary>
        /// Gets all section items as a Dictionary.
        /// </summary>
        public Dictionary<string, HtmlTableRow> Rows
        {
            get
            {
                var sectionItems = new Dictionary<string, HtmlTableRow>();
                var sectionContainers1 = this.Element.FindElements(By.ClassName("odd"));
                var sectionContainers2 = this.Element.FindElements(By.ClassName("even"));

                for (int i = 0; i < sectionContainers1.Count; i++)
                {
                    if (sectionContainers1[i].Displayed)
                    {
                        var inlineSectionItem = new HtmlTableRow(this.page, sectionContainers1[i]);
                        if (!sectionItems.ContainsKey(inlineSectionItem.Name))
                            sectionItems.Add(inlineSectionItem.Name, inlineSectionItem);
                    }
                    if (i < sectionContainers2.Count && sectionContainers2[i].Displayed)
                    {
                        var inlineSectionItem = new HtmlTableRow(this.page, sectionContainers2[i]);
                        if (!sectionItems.ContainsKey(inlineSectionItem.Name))
                            sectionItems.Add(inlineSectionItem.Name, inlineSectionItem);
                    }
                }

                //foreach (var item in sectionContainers1)
                //{
                //    if (item.Displayed)
                //    {
                //        var inlineSectionItem = new HtmlTableRow(this.page, item);
                //        if (!sectionItems.ContainsKey(inlineSectionItem.Name))
                //            sectionItems.Add(inlineSectionItem.Name, new HtmlTableRow(this.page, item));
                //    }
                //}
                //foreach (var item in sectionContainers2)
                //{
                //    if (item.Displayed)
                //    {
                //        var inlineSectionItem = new HtmlTableRow(this.page, item);
                //        if (!sectionItems.ContainsKey(inlineSectionItem.Name))
                //            sectionItems.Add(inlineSectionItem.Name, new HtmlTableRow(this.page, item));
                //    }
                //}

                return sectionItems;
            }
        }

        //public void SelectItem(string name)
        //{
        //    Items[name].Select();
        //}
    }
}