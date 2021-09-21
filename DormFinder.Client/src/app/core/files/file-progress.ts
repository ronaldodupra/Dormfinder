export enum FileProgressState {
  NotStarted = 'Not Started',
  Sending = 'Sending',
  InProgress = 'In Progress',
  Receiving = 'Receiving',
  Success = 'Success',
  Failed = 'Failed',
}

export class FileProgress<T> {
  constructor(
    public state: string,
    public percentage: number,
    public body?: T
  ) {}

  isInProgress(): boolean {
    return (
      this.state === FileProgressState.InProgress ||
      this.state === FileProgressState.Sending ||
      this.state === FileProgressState.Receiving
    );
  }

  isResolved(): boolean {
    return (
      this.state === FileProgressState.Success ||
      this.state === FileProgressState.Failed
    );
  }

  isSuccess(): boolean {
    return this.state === FileProgressState.Success;
  }

  isFailed(): boolean {
    return this.state === FileProgressState.Failed;
  }
}
