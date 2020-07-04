using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_MVC_Core.BootstrapModal
{
    public class ModalFooter
    {
        public string SubmitButtonText { get; set; } = "Submit";
        public string urlPOST { get; set; } 
        public string IdEntity { get; set; }
        public string IdForm { get; set; }


        public string CancelButtonText { get; set; } = "Cancel";
        public string SubmitButtonID { get; set; } = "btn-submit";
        public string CancelButtonID { get; set; } = "btn-cancel";
        public bool OnlyCancelButton { get; set; }
    }
}
