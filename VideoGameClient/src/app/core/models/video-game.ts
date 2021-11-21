import { GameType } from "./enums";
import { Platform } from "./platform";
import { Publisher } from "./publisher";

export interface VideoGame {
    id: number;
    name: string;
    description: string;
    platforms: Platform[];
    publisher: Publisher;
    gameType: GameType;
}