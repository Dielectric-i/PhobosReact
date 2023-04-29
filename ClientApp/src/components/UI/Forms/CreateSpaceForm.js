import { useState } from 'react';

const CreateSpaceForm = () => {
    const [inputName, setInputName] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('Submitted:', inputName);
    }

    const handleInputChange = (e) => {
        setInputName(e.target.value);
    }

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="my-input">Enter text:</label>
            <input id="my-input" type="text" value={inputName} onChange={handleInputChange} />
            <button type="submit">Submit</button>
        </form>
    );
}

export default CreateSpaceForm;