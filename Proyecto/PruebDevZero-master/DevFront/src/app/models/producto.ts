import { Proveedor } from "./proveedor";

export class Producto {
    codigo : number;
    nombre : string;
    descuento : number;
    iva : number;
    totalDescuento : number;
    totalIva: number;
    precio : number;
    total : number;
    
    fecha: string;
    description: string;
    cantidad: number;
    proveedor : Proveedor;
    
}
