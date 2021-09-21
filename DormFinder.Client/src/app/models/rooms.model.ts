import { IBuilding } from './buildings.model';
import { IFile } from './File.model';


export interface IRoom {
    building:IBuilding,
    description:string,
    electricMeterNumber:string,
    id:number,
    basicRent:number,
    roomInclusion:IRoomInclusion[],
    roomName:string,
    roomType:IRoomType,
    waterMeterNumber:string,
    roomNumber:string,
    securityDeposit:number,
    advanceRent:number,
    occupant:number,
    roomPics:IFile

}
export interface IRoomType{
  id:number,
  roomTypeName:string,  
}
interface IUtility {
    internalId: string,
    meterNumber: string,
    initialReading: number
}
export interface ICreateRoom{
    roomName:string,
    buildingName:string,
    area:number,
    roomNumber:string,
    description:string,
    basicRent:number,
    type:number,
    inclusion:IRoomInclusion[],
    id:number;
    
}
export interface IRoomInclusion{
    id:number,
    inclusion:IInclusionName;
}
export interface IInclusionName{
    inclusionName:string,
}