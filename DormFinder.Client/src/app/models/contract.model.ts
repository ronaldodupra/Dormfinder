import { ICharge } from './charge.model';

export interface IAddContract {
  id: string;
  rentalEffectivityDate: any;
  moveInDate: any;
  moveOutDate: any;
  rentalEndDate: any;
  reservationStartDate: any;
  reservationExpirationDate: any;
  allowableReservationDays: number;
  basicRent: number;
  status: string;
  tenant: {
    internalId: string;
    fullName: string;
  };
  roomId: number;
  unit: {
    internalId: string;
    unitNumber: string;
  };
  bedspace: {
    internalId: string;
    bedspaceNumber: string;
  };
  contractDeposit: IContractDeposit;
  chargeContract: number[];
  userId: number;
  approve: boolean;
}

export interface IContract {
  internalId: string;
  id: string;
  rentalEffectivityDate: any;
  moveInDate: any;
  moveOutDate: any;
  rentalEndDate: any;
  reservationStartDate: any;
  reservationExpirationDate: any;
  allowableReservationDays: number;
  basicRent: number;
  status: string;
  tenant: {
    internalId: string;
    fullName: string;
    id: number;
  };
  roomId: number;
  unit: {
    internalId: string;
    unitNumber: string;
  };
  bedspace: {
    internalId: string;
    unitNumber: string;
  };
  securityDeposit: number;
  userId: number;
  contractDeposit: IContractDeposit;
  contractCheckList: IContractChecklist;
  contractCharge: ContractCharge[];
  approve: boolean;
}

export interface ContractCharge {
  charge: ICharge;
}

export interface IContractDeposit {
  reservationFee: number;
  earlyTerminationFee: number;
  securityDeposit: number;
  rfidDeposit: number;
  rentalPdcs: IRentalPdc[];
}

export interface IRentalPdc {
  checkNumber: string;
  bank: string;
  branch: string;
  accountNumber: string;
  amount: number;
  checkDate: any;
  maturityDate: any;
}

export interface IContractChecklist {
  studentId: string;
  parentId: string;
  parentIdType: string;
}

export interface IUpdateContract {
  internalId: string;
  id: string;
  rentalEffectivityDate: any;
  moveInDate: any;
  moveOutDate: any;
  rentalEndDate: any;
  reservationStartDate: any;
  reservationExpirationDate: any;
  allowableReservationDays: number;
  basicRent: number;
}
