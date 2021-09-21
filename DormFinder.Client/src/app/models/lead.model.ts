import { IContract } from 'src/app/models/contract.model';
import { IRoom } from './rooms.model';
import { IUser } from './user.model';

export interface IAddlead {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  email: string;
  number: number;
  message: string;
  roomId: number;
  room: IRoom;
  createdAt: string;
  contract: IContract;
}

export interface Ilead {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  email: string;
  number: number;
  message: string;
  roomId: number;
  room: IRoom;
  createdAt: string;
  contract: IContract;
  userId: number;
}
