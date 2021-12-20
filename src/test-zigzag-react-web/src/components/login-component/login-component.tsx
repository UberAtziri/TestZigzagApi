import { Form, Input, Button, Row, Col, Typography } from 'antd';
import { useDispatch, useSelector } from 'react-redux';
import { logInAsync, logInErrorSelector, setLoginErrorState } from '../../redux/slices/authSlice';
import { useState } from 'react';
import { authService } from '../../services/authService';
import { LoginRegisterModel } from '../../models/auth';

const {Text} = Typography;

export const Login = () => {
	const [isLoginForm, setIsLoginForm] = useState(true);
	const [registerMessage, setRegisterMessage] = useState('');
	const [registerFailed, setRegisterFailed] = useState(false);
	const dispatch = useDispatch();
	const loginErrorState = useSelector(logInErrorSelector);
	const [loginForm] = Form.useForm();

	const onFinish = async (request: LoginRegisterModel) => {
		if (isLoginForm) {
			dispatch(logInAsync(request));
		} else {
			authService.register(request).then(x => {
				setRegisterFailed(false);
				setRegisterMessage('Success!');
			}, () => {
				setRegisterFailed(true);
				setRegisterMessage('Non success!');
			});
		}
	};

	const clearErrors = () => {
		if (loginErrorState) {
			dispatch(setLoginErrorState(null));
		}
	}

	const onRegisterClick = () => {
		loginForm.resetFields();
		setRegisterMessage('');
		setIsLoginForm((isLogin) => !isLogin);
	}

	const getSuccessMessage = () => {
		return (<Text type={registerFailed ? 'danger' : 'success'}>{registerMessage}</Text>)
	}

	return (
		<Row justify="center" align="middle" style={{height: '100vh', flexDirection: 'column'}}>
			<Row justify="center">
				<h1>{isLoginForm ? 'Log in' : 'Sign up'}</h1>
			</Row>
			<Form
				name="basic"
				labelCol={{
					span: 8,
				}}
				wrapperCol={{
					span: 16,
				}}
				initialValues={{
					remember: true,
				}}
				onFinish={onFinish}
				autoComplete="off"
				form={loginForm}
			>
				<Form.Item
					label="Username"
					name="userName"
					validateStatus={loginErrorState ? 'error' : ''}
					help={loginErrorState}
					rules={[
						{
							required: true,
							message: 'Please input your username!',
						},
					]}
				>
					<Input onChange={clearErrors}/>
				</Form.Item>

				<Form.Item
					label="Password"
					name="password"
					rules={[
						{
							required: true,
							message: 'Please input your password!',
						},
					]}
				>
					<Input.Password/>
				</Form.Item>
				<Row justify="center" gutter={16}>
					{getSuccessMessage()}
				</Row>
				<Row justify="center" gutter={16}>
					<Col>
						<Form.Item>
							<Button type="primary" htmlType="submit">
								Submit
							</Button>
						</Form.Item>
					</Col>

					<Col>
						<Form.Item>
							<Button type="link" onClick={onRegisterClick}>
								{isLoginForm ? 'Sign up' : 'Log in'}
							</Button>
						</Form.Item>
					</Col>
				</Row>
			</Form>
		</Row>
	);
};
