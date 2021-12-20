import { axiosInstance } from './index';
import { LoginRegisterModel, LoginResponse } from '../models/auth';
import { AxiosResponse } from 'axios';

export const authService = {
	logIn: async (request: LoginRegisterModel): Promise<LoginResponse> => {
		const response = await axiosInstance.get('auth/token', {params: request});
		
		return response.data;
	},

	register: async (request: LoginRegisterModel): Promise<AxiosResponse> => {
		return await axiosInstance.post('auth/register', request);
	}
}