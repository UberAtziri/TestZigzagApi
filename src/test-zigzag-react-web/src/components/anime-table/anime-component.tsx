import { Button, Row, Col, Table, Select } from 'antd';
import { useDispatch } from 'react-redux';
import { ColumnsType } from 'antd/es/table';
import React, { useEffect, useState } from 'react';
import { logOut } from '../../redux/slices/authSlice';
import { animeService } from '../../services/animeService';
import { Anime } from '../../models/anime';
import moment from 'moment';
import { sortDates, sortEverything } from '../../common/helpers/commonHelpers';
import { CreateAnimeModal } from './create-anime-modal/create-anime-modal-component';

const {Option} = Select;

const columns: ColumnsType<Anime> = [
	{
		title: 'Name',
		dataIndex: 'name',
		key: 'name',
		sorter: (a, b) => sortEverything(a.name, b.name),  
	},
	{
		title: 'Description',   
		dataIndex: 'description',
		key: 'description'
		sorter: (a, b) => sortEverything(a.description, b.description)
	},
	{
		title: 'Rating',
		dataIndex: 'rating',
		key: 'rating',
		sorter: (a, b) => sortEverything(a.rating, b.rating)
	},
	{
		title: 'Release',
		dataIndex: 'releaseDate',
		key: 'releaseDate',
		render: (value) => {
			return moment(value).format('YYYY-MM-DD');
		},
		sorter: (a, b) => sortDates(moment(a.releaseDate), moment(b.releaseDate)),
	},
	{
		title: 'Episodes',
		dataIndex: 'numberOfEpisodes',
		key: 'numberOfEpisodes',
		sorter: (a, b) => sortEverything(a.numberOfEpisodes, b.numberOfEpisodes)
	},
	{
		title: 'Category',
		dataIndex: 'categoryName',
		key: 'categoryName',
		sorter: (a, b) => sortEverything(a.categoryName, b.categoryName)
	}

];
export const AnimeComponent = () => {
	const [animeList, setAnimeList] = useState<Anime[]>([]);
	const [isAddAnimeModalVisible, setIsAddAnimeModalVisible] = useState(false);
	const [categoryList, setCategoryList] = useState<any[]>([]);
	const [selectedCategory, setSelectedCategory] = useState<string | undefined>(undefined);

	const dispatch = useDispatch();

	const showAddAnimeModal = () => {
		setIsAddAnimeModalVisible(true);
	};

	const getAnimeList = async (): Promise<void> => {
		const result = await animeService.getAllByCategory(selectedCategory || '');
		setAnimeList(result);
	}

	const getCategories = async (): Promise<void> => {
		const result = await animeService.getCategories();
		setCategoryList(result);
	}

	const onLogOut = () => {
		dispatch(logOut());
	}

	const onCategoryChange = (value: string) => {
		setSelectedCategory(value);
	}

	const getData = async () => {
		await getCategories();
		await getAnimeList();
	}
	useEffect(() => {
		getCategories();
	}, []);

	useEffect(() => {
		getAnimeList();
	}, [selectedCategory]);

	return (
		<Row style={{width: '100%'}} justify="center">
			<Row>
				<Table rowKey="id" pagination={{position: ['bottomCenter']}} columns={columns} dataSource={animeList}/>
			</Row>
			<Row style={{width: '100%'}} justify="center" gutter={16}>
				<Col>
					<Select placeholder="Select category" allowClear style={{width: 200}} onChange={onCategoryChange} value={selectedCategory}>
						{categoryList.map(x => <Option key={x} value={x}>{x}</Option>)}
					</Select>
				</Col>

				<Col>
					<Button onClick={showAddAnimeModal}>Add anime</Button>
				</Col>
				<Col>
					<Button onClick={onLogOut}>Log out!</Button>
				</Col>
				
				<CreateAnimeModal 
					isAddAnimeModalVisible={isAddAnimeModalVisible}
					onAnimeCreated={getData}
					setIsAnimeModalVisible={setIsAddAnimeModalVisible}/>
			</Row>
		</Row>
	);
};
