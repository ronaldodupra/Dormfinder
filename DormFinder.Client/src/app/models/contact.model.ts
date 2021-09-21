export interface IContact {
    internalId: string,
    firstName: string,
    lastName: string,
    middleName: string,
    type: string,
    address: string,
    landlineNumber: string,
    mobileNumber: string,
    emailAddress: string,
    yearOfStudy: string,
    education: string,
    birthday: Date,
    hobbies: string[]
    status: string
}