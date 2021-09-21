export interface ITenant {
  id: number;
  user: {
    firstName: string;
    lastName: string;
    fullName: string;
    email: string;
    phoneNumber: string;
    address: string;
  };
  contract: {
    effectiveStartDate: Date;
    effectiveEndDate: Date;
    basicRent: number;
    securityDeposit: number;
  };
  building: {
    name: string;
    address: string;
  };
  room: {
    unit: string;
  };
}

export interface ICreateTenant {
  contractId: number;
  roomId: number;
  userId: number;
}
