import React from 'react';
import { useSelector } from 'react-redux';
import { isLoggedInSelector } from './redux/slices/authSlice';
import './styles/App.styles.css';
import { Row } from 'antd';
import { interceptor } from './services';
import { store } from './redux/store';
import { AnimeComponent } from './components/anime-table/anime-component';
import { Login } from './components/login-component/login-component';

interceptor(store);

function App() {
	const isLoggedIn = useSelector(isLoggedInSelector);

	return isLoggedIn
		?
		<Row justify="center" align="middle" style={{height: '100vh'}}>
			<AnimeComponent/>
		</Row>
		: 
		<Login/>
}

export default App;
