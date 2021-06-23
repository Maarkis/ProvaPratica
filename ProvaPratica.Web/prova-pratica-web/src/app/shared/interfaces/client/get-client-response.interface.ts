import { BaseResponse } from "../responseBase/base-response.interface";
import { Client } from "./client.interface";

export interface GetClientResponse extends BaseResponse {
    client: Client;
}