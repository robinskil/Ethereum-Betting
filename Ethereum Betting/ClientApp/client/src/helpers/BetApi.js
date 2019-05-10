
const store = [{
    id: 1,
    amount: 123,
    title: "Weather forecast June 25th",
    duration: "2 days"
},
{
    id: 1,
    amount: 123,
    title: "Weather forecast June 27th",
    duration: "1 day"
},
{
    id: 1,
    amount: 123,
    title: "Weather forecast June 28th",
    duration: "23 days"
}]

export const betApi = {
    async getMyBets() {
        return store;
    }
}