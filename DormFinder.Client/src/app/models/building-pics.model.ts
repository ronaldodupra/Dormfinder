export interface IBuildingPic {
    internalId: string,
    buildingId: string,
    type: string,
    roomId: string,
    fileName: string,
    fileType: string,
    fileBase64: string, //can't find mongoDB base64 datatype so made another variable
    description: string,
    isViewable: boolean
}
