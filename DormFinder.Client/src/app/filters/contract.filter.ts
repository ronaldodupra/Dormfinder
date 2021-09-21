import { ClrDatagridStringFilterInterface } from "@clr/angular";
import { IContract } from "../models/contract.model";

export class TenantNameFilter implements ClrDatagridStringFilterInterface<IContract> {
    accepts(item: IContract, search: string): boolean {
        return "" + item.tenant.fullName == search
            || (item.tenant.fullName).toLowerCase().indexOf(search) >= 0;
    }
}

export class UnitNumberFilter implements ClrDatagridStringFilterInterface<IContract> {
    accepts(item: IContract, search: string): boolean {
        return "" + item.unit.unitNumber == search
            || (item.unit.unitNumber).toLowerCase().indexOf(search) >= 0;
    }
}


