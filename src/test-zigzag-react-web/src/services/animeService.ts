import { axiosInstance } from './index';
import { Anime, CreateAnimeModel } from '../models/anime';

export const animeService = {
	getAllByCategory: async (categoryName: string): Promise<Anime[]> => {
		const result = await axiosInstance.get(`anime/category`, {params: {categoryName}});
		
		return result.data;
	},
	
	getCategories: async (): Promise<string[]> => {
		const result = await axiosInstance.get('categories');

		return result.data;
	},
	
	createAnime: async(request: CreateAnimeModel): Promise<Anime> => {
		const result = await axiosInstance.post('anime', request);
		
		return result.data;
	}
}