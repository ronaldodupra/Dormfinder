import { IRoom } from './rooms.model';

export interface IBuilding {
  id: string;
  name: string;
  description: string;
  address: {
    province: string;
    city: string;
    addressLine1: string;
    addressLine2: string;
    latitude: number;
    longitude: number;
  };
  floors:IFloors[]
  buildingNearbyPlaces:IBuildingNearByPlace[],
}
export interface IFloors {
    id:number;
    description:string 
}
export interface ICreateBuilding {
  name: string;
  description: string;
  address: {
    province: string;
    city: string;
    line1: string;
    line2: string;
  };
}
export interface IBuildingNearByPlace{
  place:string;
}
