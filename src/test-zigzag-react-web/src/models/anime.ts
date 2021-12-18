import moment from "moment";

export interface Anime {
	id: string;
	name: string;
	rating: number;
	numberOfEpisodes: number;
	description: string;
	releaseDate: string;
	categoryName: string;
}

export interface CreateAnimeModel {
	name: string;
	rating: number;
	numberOfEpisodes: number;
	description: string;
	releaseDate: moment.Moment;
	categoryName: string;
}