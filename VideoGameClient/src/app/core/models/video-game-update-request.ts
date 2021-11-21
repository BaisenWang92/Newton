import { GameType } from "./enums";

export interface VideoGameUpdateRequest {
    id: number;
    name: string;
    description: string;
    platformIds: number[];
    publisherId: number;
    gameType: GameType;
}