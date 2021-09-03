using System.Collections.Generic;
using Entidad;

namespace devzero.Models
{
    public class FacturaCompraInputModel
    {
        public List<DetalleInputModel> DetallesFactura{get; set;}
        public string UsuarioId{get; set;}
        public string ProveedorId{get; set;}
    }

    public class FacturaCompraViewModel : FacturaCompraInputModel{
        public FacturaCompraViewModel()
        {
            
        }

        public FacturaCompraViewModel(FacturaCompra facturaCompra)
        {
            UsuarioId=facturaCompra.UsuarioId;
            ProveedorId=facturaCompra.ProveedorId;
        }


    }

}