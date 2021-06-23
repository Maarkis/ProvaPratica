import { BaseResponse } from "../responseBase/base-response.interface";
import { Convenio } from "./convenio.interface";

export interface GetAllConvenioResponse extends BaseResponse {
    convenios: Convenio[];
}