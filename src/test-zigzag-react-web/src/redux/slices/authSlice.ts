import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { authService } from '../../services/authService';
import { AppThunk, RootState } from '../store';
import { LoginRegisterModel } from '../../models/auth';
import { commonConstants } from '../../common/constants/commonConstants';

interface AuthState {
	isLoggedIn: boolean;
	accessToken: string | null;
	logInErrorMessage: string | null;
}

const initialState: AuthState = {
	isLoggedIn: true,
	accessToken: null,
	logInErrorMessage: null,
};

export const logInAsync = (request: LoginRegisterModel): AppThunk => async (dispatch) => {
	try {
		const result = await authService.logIn(request);
		dispatch(setSuccessAuthState(result.accessToken));
	} catch (e) {
		dispatch(setLoginErrorState(e.response.data.error));
	}
}

export const setSuccessAuthState = (accessToken: string): AppThunk => (dispatch) => {
	localStorage.setItem(commonConstants.ACCESS_TOKEN_LOCAL_STORAGE_KEY, accessToken);
	dispatch(setTokenState(accessToken));
	dispatch(setAuthState(true));
}

export const logOut = (): AppThunk => (dispatch) => {
	localStorage.removeItem(commonConstants.ACCESS_TOKEN_LOCAL_STORAGE_KEY);
	dispatch(setAuthState(false));
	dispatch(setTokenState(null));
}

export const authSlice = createSlice({
	name: 'auth',
	initialState,
	reducers: {
		setAuthState: (state, action: PayloadAction<boolean>) => {
			return {
				...state,
				isLoggedIn: action.payload
			};
		},
		setTokenState: (state, action: PayloadAction<string | null>) => {
			return {
				...state,
				accessToken: action.payload
			};
		},
		setLoginErrorState: (state, action: PayloadAction<string | null>) => {
			return {
				...state,
				logInErrorMessage: action.payload
			};
		}
	},
});

export const {setAuthState, setTokenState, setLoginErrorState} = authSlice.actions;

export const isLoggedInSelector = (state: RootState) => state.auth.isLoggedIn;

export const logInErrorSelector = (state: RootState) => state.auth.logInErrorMessage;

export default authSlice.reducer;
