import { Sexo } from "./sexo.enum";

export interface UpdateClientRequest {
    prontuario: number;
    nome: string;
    sobrenome: string;
    dt_Nasc: string;
    sexo: Sexo;
    email: string;
    celular: string;
    fone_Res: string;
    id_Convenio: number;
    n_Carteirinha: string;
}