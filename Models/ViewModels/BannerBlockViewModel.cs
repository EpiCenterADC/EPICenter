using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiCenterBaseProject.Models.Blocks;
using EPiServer.Editor;
using System.Text.RegularExpressions;

namespace EPiCenterBaseProject.Models.ViewModels
{
    public class BannerBlockViewModel
    {
        public BannerBlock BannerBlock { get; set; }

        public bool IsPageInEditMode
        {
            get
            {
                bool isInEditMode = false;
                if (HttpContext.Current.Request.UrlReferrer != null)
                {
                    isInEditMode = Regex.IsMatch(HttpContext.Current.Request.UrlReferrer.LocalPath.ToLower(), "/episerver/cms/", RegexOptions.IgnoreCase);

                    if (isInEditMode || PageEditing.PageIsInEditMode)
                        isInEditMode = true;
                    else
                        isInEditMode = false;
                }
                return isInEditMode;

                //return PageEditing.PageIsInEditMode;
            }
        }
    }
}