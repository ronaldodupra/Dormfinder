import { IAddress } from './address.model';

export interface IUser{
    id: number,
    firstName: string,
    lastName: string,
    originalImageId: number,
    userType: string,
    status: string;
    verifiedAt: Date,
    addressId: number,
    address: IAddress,
    student: boolean,
    school: string,
    course: string,
    gender: string    
}