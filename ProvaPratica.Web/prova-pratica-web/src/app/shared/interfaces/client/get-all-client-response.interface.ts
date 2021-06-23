import { Client } from "./client.interface";
import { BaseResponse } from "../responseBase/base-response.interface";


export interface GetAllClientResponse extends BaseResponse {
    clients: Client[];
}