export interface Planning {
    idReleveur: number;
    liblocalite: string;
    tspUsername: number;
    idPort: number;
    marquePort: string;
    tournee: {
        idTour: Array <number>;
        tour: Array <number>;
    };
    datAffect: Date;
}
