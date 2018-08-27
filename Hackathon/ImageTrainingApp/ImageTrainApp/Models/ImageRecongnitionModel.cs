using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageTrainApp.Models
{
    public class ImageRecongnitionModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}