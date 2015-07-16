using System.Web.Mvc;

namespace EPiCenterBaseProject.Business
{
    public class RenderHelper
    {
        public ControllerBase CurrentController { get; private set; }

        public RenderHelper(ControllerBase controller)
        {
            CurrentController = controller;
        }

        /// <summary>
        /// Method to generate the view as a HTML string.
        /// </summary>
        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = CurrentController.ControllerContext.RouteData.GetRequiredString("action");
            }

            CurrentController.ViewData.Model = model;

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(CurrentController.ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(CurrentController.ControllerContext, viewResult.View, CurrentController.ViewData, CurrentController.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}