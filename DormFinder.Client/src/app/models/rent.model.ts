export class IRent{
    basicRent:number;
    roomPics:IRoomPic[];
    roomName:string;
    thumbnail:string;
    building:IRentBuilding
}
export class IRoomPic{
    isThumbnail:boolean;
    fileEntryId:number;
}
export class IRentBuilding {
    address:IRentBuildingAddress;
    id:number;
}
export class IRentBuildingAddress{
    city:string;
    province:string;
    line1:string;
    line2:string;
}
