
export const convertIsoToDate = (dateString: string): Date => {
    return new Date(dateString);
};

export const formatDateToReadableString = (date: Date): string => {
    const options: Intl.DateTimeFormatOptions = { year: 'numeric', month: 'long', day: 'numeric' };
    return date.toLocaleDateString(undefined, options);
};
