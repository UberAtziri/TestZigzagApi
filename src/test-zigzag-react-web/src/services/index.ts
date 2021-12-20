import axios from 'axios';
import { logOut } from '../redux/slices/authSlice';
import { commonConstants } from '../common/constants/commonConstants';

export const axiosInstance = axios.create({
	baseURL: commonConstants.BASE_URL,
	responseType: 'json'
});

export const interceptor = (store: any) => {
	axiosInstance.interceptors.request.use(
		(req) => {
			const token = localStorage.getItem('accessToken');
			if (req && req.headers && token) {
				req.headers['Authorization'] = `Bearer ${token}`;
			}
			return req;
		})
	axiosInstance.interceptors.response.use(
		(next) => next,
		(error) => {
			if(error.response.status === 401) {
				store.dispatch(logOut());
			}
			return Promise.reject(error);
		}
	);
};
