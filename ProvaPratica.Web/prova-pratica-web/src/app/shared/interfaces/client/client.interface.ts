import { Sexo } from "./sexo.enum";

export interface Client {
    prontuario: number;
    nome: string;
    sobrenome: string;
    dt_Nasc: string;
    sexo: Sexo;
    cpf: string;
    rg: string;
    ufrg: string;
    email: string;
    celular: string;
    fone_Res: string;
    id_Convenio: number;
    n_Carteirinha: string;
}

