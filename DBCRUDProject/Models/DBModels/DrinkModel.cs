using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCRUD.Models.DBModels
{

    /// <summary>
    /// [AdventureWorksLT2016].[dbo].[BuildVersion] Model
    /// </summary>
    public class DrinkModel
    {
        /// <summary>
        /// Primary key for BuildVersion records.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Required]
        public DateTime UpdateTime { get; set; }
    }
}
