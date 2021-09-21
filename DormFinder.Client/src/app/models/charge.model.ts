import { IChargeType } from './chargetype.model';

export interface ICharge {
  id: number;
  name: string;
  comments: string;
  defaultCharge: string;
  amount: number;
  billingStatementOrder: number;
  isVat: boolean;
  date: Date;
  chargeTypeId: number;
  chargeType: IChargeType;
}

export interface ICreateCharge {
  name: string;
  comments: string;
  defaultCharge: string;
  amount: number;
  billingStatementOrder: number;
  isVat: boolean;
  date: Date;
  chargeTypeId: number;
}
