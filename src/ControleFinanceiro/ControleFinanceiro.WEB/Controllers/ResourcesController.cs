using System.Collections;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ControleFinanceiro.CORE.Resources;
using ControleFinanceiro.Helpers;

namespace ControleFinanceiro.WEB.Controllers
{
    public class ResourcesController : Controller
    {
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public ActionResult GetResourcesJavaScript(string resxFileName)
        {
            ResourceManager resourceManager = null;
            switch (resxFileName.ToLower())
            {
                case "globalsresource":
                    {
                        resourceManager = new ResourceManager("ControleFinanceiro.CORE.Resources.GlobalsResource", typeof(GlobalsResource).Assembly);
                        break;
                    }
                case "labelsresource":
                    {
                        resourceManager = new ResourceManager("ControleFinanceiro.CORE.Resources.LabelsResource", typeof(LabelsResource).Assembly);
                        break;
                    }
                case "messagesresource":
                    {
                        resourceManager = new ResourceManager("ControleFinanceiro.CORE.Resources.MessagesResource", typeof(MessagesResource).Assembly);
                        break;
                    }
            }

            if(resourceManager != null)
            {
                var resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

                var resourceDictionary = resourceSet.Cast<DictionaryEntry>()
                                    .ToDictionary(entry => entry.Key.ToString(), entry => entry.Value.ToString());

                var json = Serializer.Serialize(resourceDictionary);
                var javaScript = string.Format("window.Resources = window.Resources || {{}}; window.Resources.{0} = {1};", resxFileName, json);
                return JavaScript(javaScript);
            }
            return JavaScript("");

        }


        public ActionResult GetCustomExtends(string extFileName)
        {
            var sbExtends = new StringBuilder();
          
            sbExtends.Append(" $.fn.extend({");
            sbExtends.Append(string.Format("appAssetsPath: \"{0}\",",AppHelper.AssetsPath));
            sbExtends.Append(string.Format(" appRootDomainPath: \"{0}\"", AppHelper.RootDomain));
            sbExtends.Append("  });");
           
            return JavaScript(sbExtends.ToString());
        }
    }
}
