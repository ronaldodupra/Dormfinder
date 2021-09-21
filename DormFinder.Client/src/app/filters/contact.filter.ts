import { ClrDatagridStringFilterInterface } from "@clr/angular";
import { IContact } from "../models/contact.model";

export class FullNameFilter implements ClrDatagridStringFilterInterface<IContact> {
    accepts(item: IContact, search: string): boolean {
        return "" + item.firstName + item.lastName + item.middleName == search
            || (item.firstName + item.lastName + item.middleName).toLowerCase().indexOf(search) >= 0;
    }
}