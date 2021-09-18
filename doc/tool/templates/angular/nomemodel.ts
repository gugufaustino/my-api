import { MappingModel } from "src/app/base-contracts/models/mapping.model";


export class #NomeModel# implements MappingModel {
    constructor() { this.toMap(); }

    id: number;
    nome: string;    
    

    mappings: any[];
    toMap(): void {
        this.mappings = [
            { id: "number" },
            { nome: "stringr" },
            ];
    }


}