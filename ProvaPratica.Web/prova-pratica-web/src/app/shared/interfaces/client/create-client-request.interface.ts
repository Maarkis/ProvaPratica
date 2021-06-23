import { Sexo } from "./sexo.enum";

export interface CreateClientRequest {
    nome: string;
    sobrenome: string;
    dt_Nasc: string;
    sexo: Sexo;
    cPF: string;
    rG: string;
    uFRG: string;
    email: string;
    celular: string;
    fone_Res: string;
    id_Convenio: number;
    n_Carteirinha: string;
}