import { ClrDatagridStringFilterInterface } from "@clr/angular";
import { IBuilding } from "../models/buildings.model";

export class BuildingNameFilter implements ClrDatagridStringFilterInterface<IBuilding> {
    accepts(item: IBuilding, search: string): boolean {
        return "" + item.name == search
            || (item.name).toLowerCase().indexOf(search) >= 0;
    }
}