import { IAddress } from './address.model';

export class IProperty{
    name:string;
    description:string;
    address:IAddress;
}
export class IPropertyLocation{
    province:string;
    city:string;
    count:number;
    addressName:string
}