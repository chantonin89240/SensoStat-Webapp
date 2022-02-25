import axios from 'axios';

export default class PresentationService {
    async postResponse(token ,idInstruction, idProduct, idPanelist, response) {
        return new Promise((resolve) => {
            axios.post("https://localhost:5001/api/Pwa", {
                headers: {
                    Authorization: token
                }
            },
            {
                idInstruction: idInstruction,
                idProduct: idProduct,
                idPanelist: idPanelist,
                commentResponse: response
            })
        })
    }

    async getSession(token) {
        return new Promise((resolve) => {
            axios.get("https://localhost:5001/api/Pwa?hash=" + token).then((response) => {
                    resolve(response.data)
                })
            })
    }

}