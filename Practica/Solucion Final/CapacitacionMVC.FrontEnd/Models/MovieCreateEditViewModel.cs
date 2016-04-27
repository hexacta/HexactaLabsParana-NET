using CapacitacionMVC.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapacitacionMVC.FrontEnd.Models
{
    public class MovieCreateEditViewModel
    {
        public IList<Genre> Genres { get; set; }

        public Movie Movie { get; set; }
    }
}