using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBCRUDProject.Models.APIModels
{
    public class UpdateDrinkModel
    {
        /// <summary>
        /// Primary key for BuildVersion records.
        /// </summary>
        [Required]
        public int DrinkID { get; set; }

        /// <summary>
        /// Version number of the database in 9.yy.mm.dd.00 format.
        /// </summary>
        [Required]
        public string DrinkName { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Required]
        public int DrinkPrice { get; set; }
    }
}
