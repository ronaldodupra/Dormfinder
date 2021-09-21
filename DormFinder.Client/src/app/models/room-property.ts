import { IAddress } from './address.model';
export class IRoomProperty{
    roomName:string;
    description:string;
    basicRent:number;
    area:number;
    roomNumber:string;
    building:IBuilding;
    roomInclusion:IRoomInclusion[];
    roomType:IRoomType;
    roomPics:IRoomPic[];
    
}
export class IBuildingPics{
    fileEntryId:number;
}
export class IRoomPic{
    fileEntryId:number;
    isThumbnail:boolean
}
export class IRoomInclusion{
    inclusion:IInclusion;
}
export class IRoomType{
    roomTypeName:string;
}
export class IInclusion{
    inclusionName:string;
}
export class IBuilding{
    name:string;
    description:string;
    address:IAddress;
    amenities:string;
    buildingPics:IBuildingPics[];
    buildingAmenities:IBuildingAmenity[];
}

export class IBuildingAmenity{
    amenity:{
        description:string;
    }
}