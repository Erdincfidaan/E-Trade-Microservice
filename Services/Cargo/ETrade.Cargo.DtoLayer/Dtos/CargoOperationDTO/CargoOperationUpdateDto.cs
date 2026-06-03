using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DtoLayer.Dtos.CargoOperationDTO
{
    public class CargoOperationUpdateDto
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string OperationDescription { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
