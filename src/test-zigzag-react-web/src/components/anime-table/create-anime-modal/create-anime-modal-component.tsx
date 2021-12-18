import { DatePicker, Form, Input, InputNumber, Modal } from 'antd';
import { CreateAnimeModel } from "../../../models/anime";
import { animeService } from "../../../services/animeService";

interface CreateAnimeModalProps {
    isAddAnimeModalVisible: boolean;
    onAnimeCreated: () => void;
    setIsAnimeModalVisible: (x: boolean) => void;
}

export const CreateAnimeModal: React.VFC<CreateAnimeModalProps> = (props) => {
    const [createAnimeForm] = Form.useForm<CreateAnimeModel>();
    
    const onSubmit = () => {
        createAnimeForm.validateFields().then((x) => {
            animeService.createAnime(x).then(() => {
                createAnimeForm.resetFields();
                props.onAnimeCreated();
                props.setIsAnimeModalVisible(false);
            });
        }, () => {
            return;
        });
	};

    const onCancel = () => {
        props.setIsAnimeModalVisible(false);
        createAnimeForm.resetFields();
    }

    return (
        <Modal title="Anime creating" visible={props.isAddAnimeModalVisible} onOk={onSubmit} onCancel={onCancel}>
            <Form
                name="createAnime"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                form={createAnimeForm}
            >
                <Form.Item
                    label="Name"
                    name="name"
                    rules={[{ required: true, message: 'Name is required.' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Description"
                    name="description"
                    rules={[{ required: true, message: 'Description is required.' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Rating"
                    name="rating"
                    rules={[{ required: true, message: 'Input is required.' }]}
                >
                    <InputNumber min={1} max={10} />
                </Form.Item>

                <Form.Item
                    label="Number of episodes"
                    name="numberOfEpisodes"
                    rules={[{ required: true, message: 'Number of episodes is required.' }]}
                >
                    <InputNumber min={1} max={10000} />
                </Form.Item>

                <Form.Item
                    label="Category"
                    name="categoryName"
                    rules={[{ required: true, message: 'Category is required.' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Release date"
                    name="releaseDate"
                    rules={[{ required: true, message: 'Release date is required.' }]}
                >
                    <DatePicker />
                </Form.Item>

            </Form>
        </Modal>
    );
};
