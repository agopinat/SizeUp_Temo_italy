using System.Web.Mvc;

namespace Web.Areas.Pins
{
    public class PinsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Pins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {


            context.MapRoute(
               "BusinessMarker",
               "Pins/Business/Marker/{section}/{index}",
               new { controller = "Business", action = "Marker" },
               new string[] { "Web.Areas.Pins.Controllers" }
           );

            context.MapRoute(
                "BusinessMarkerHighlight",
                "Pins/Business/Marker/{section}/{index}/Highlight",
                new { controller = "Business", action = "MarkerHighlight" },
                new string[] { "Web.Areas.Pins.Controllers" }
            );

            context.MapRoute(
               "BusinessMarkerShadow",
               "Pins/Business/MarkerShadow",
               new { controller = "Business", action = "MarkerShadow" },
               new string[] { "Web.Areas.Pins.Controllers" }
           );

            context.MapRoute(
                "BusinessPin",
                "Pins/Business/Pin/{color}",
                new { controller = "Business", action = "Pin" },
                new string[] { "Web.Areas.Pins.Controllers" }
            );

            context.MapRoute(
               "BusinessPinShadow",
               "Pins/Business/PinShadow",
               new { controller = "Business", action = "PinShadow" },
               new string[] { "Web.Areas.Pins.Controllers" }
           );



            context.MapRoute(
                "Pins_default",
                "Pins/{controller}/{action}/",
                new { action = "Index" }

            );
        }
    }
}
