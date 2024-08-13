using LinqToDB.Mapping;
using SvaraKalkulators.Core.Data.Enums;
using SvaraKalkulators.Core.Data.Resources;
using static SvaraKalkulators.Core.Data.Resources.Columns;

namespace SvaraKalkulators.Core.Data.Models.Data
{
    [Table(Tables.Results)]
    public record ResultsModel
    {
        [Column(Results.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Column(Results.Barcode, CanBeNull = false)]
        public string Barcode { get; set; } = string.Empty;

        [Column(Results.Weight, CanBeNull = false)]
        public float Weight { get; set; }

        [Column(Results.DateTime, CanBeNull = false)]
        public DateTime DateTime { get; set; }

        [Column(Results.Mode, CanBeNull = false)]
        public Mode Mode { get; set; }
    }
}
