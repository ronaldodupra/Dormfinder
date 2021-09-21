export class IOccupant{
    id:number;
    securityDeposit:number;
    rentAdvance:number;
    occupant:number;
    tenant:{
        contract:{
            id:number
        }
    }
}