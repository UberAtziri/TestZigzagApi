export const sortEverything = (a: number | string, b: number | string) => a > b ? -1 : 1;

export const sortDates = (a: moment.Moment, b: moment.Moment) => a.isAfter(b) ? -1 : 1;